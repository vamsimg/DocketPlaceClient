using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using DocketPlaceClient.au.com.docketplace;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Data;

namespace DocketPlaceClient
{
	class MicrosoftRewards
	{

		public static string MakeConnectionString(string location, string DBname, string user, string password)
		{
			return String.Format("Data Source={0};Initial Catalog = {1}; User ID = {2}; Password = {3}", location, DBname, user, password);
		}

		private static bool CheckIfTaxInvoice(string receipt_content)
		{
               if (receipt_content.Contains("Z Report") || receipt_content.Contains("X Report") || receipt_content.Contains("ZZ Report"))
               {
                    return false;
               }
               else
               {
                    
                    string[] receiptIdentifiers = Regex.Split(Properties.Settings.Default.ReceiptIdentifiers, ",");

                    foreach (string receiptIdentifier in receiptIdentifiers)
                    {
                         if (receipt_content.Contains(receiptIdentifier))
                         {
                              return true;
                         }
                    }
                    return false;
               }
		}

		private static int ExtractDocketID(string receipt_content)
		{
			string[] lines = Regex.Split(receipt_content, "\n");

			int index = 0;
			string docketLine = "";
			foreach (string line in lines)
			{
                    if (line.Contains(Properties.Settings.Default.TransactionCaption))
				{
					docketLine = lines[index];
					break;
				}
				index++;
			}
               
			int docket_id = Convert.ToInt32(docketLine.Replace(Properties.Settings.Default.TransactionCaption, "").Replace(" ","").Trim());

			return docket_id;
		}

		/// <summary>
		/// Gets the last docket from the raw printer receipt output.
		/// </summary>
		/// <param name="receipt_content"></param>
		/// <returns></returns>
		public static LocalDocket GetLastDocket(string receipt_content)
		{
			string RMDBLocation = Properties.Settings.Default.RMDBLocation;

			if (!CheckIfTaxInvoice(receipt_content))
			{
				return null;
			}
			else
			{
				int docket_id = ExtractDocketID(receipt_content);
				return GetLocalDocket(docket_id);
			}
		}

          /// <summary>
          /// TODO Needs better error handling
          /// </summary>
          /// <param name="docket_id"></param>
          /// <returns></returns>
		private static LocalDocket GetLocalDocket(int docket_id)
		{
			LocalDocket latestDocket = new LocalDocket();

			try
			{
				// create a connection object
				SqlConnection connection = new SqlConnection(MakeConnectionString(Properties.Settings.Default.POSServerLocation,
																	 Properties.Settings.Default.POSServerDBName,
																	 Properties.Settings.Default.POSServerUser,
																	 Properties.Settings.Default.POSServerPassword));

				// create a command object
				SqlCommand selectCommand = connection.CreateCommand();
				selectCommand.CommandText = "SELECT TransactionNumber, Time, CustomerID ,total from [Transaction] where TransactionNumber = " + docket_id.ToString();

				connection.Open();

				SqlDataReader docketDataReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

				int customer_id = 0;
                                        
				while (docketDataReader.Read())
				{
					latestDocket.local_id = (int)docketDataReader["TransactionNumber"];
					latestDocket.creation_datetime = (DateTime)docketDataReader["Time"];
					customer_id = (int)docketDataReader["CustomerID"];
					latestDocket.total = (Decimal)docketDataReader["total"];
				}

				docketDataReader.Close();


				//Get docket items for transaction.
                    selectCommand.CommandText = @"SELECT Item.ID, 
                                                         Item.ItemLookupCode ,
                                                         TransactionEntry.price, 
                                                         TransactionEntry.quantity, 
		                                               Item.description, 
                                                         Department.Name as department, 
                                                         Category.Name as category ,
		                                               TransactionEntry.Cost, 
                                                         (TransactionEntry.price - TransactionEntry.SalesTax) as sale_ex                                                    
                                                  FROM TransactionEntry INNER JOIN Item ON TransactionEntry.ItemID = Item.ID 
                                                  INNER JOIN Department ON Item.DepartmentID = Department.ID 
                                                  INNER JOIN Category ON Item.CategoryID = Category.ID 
                                                  where TransactionNumber = " + latestDocket.local_id.ToString();

				SqlDataReader itemDataReader = selectCommand.ExecuteReader();

				List<LocalDocketItem> tempArray = new List<LocalDocketItem>();

				while (itemDataReader.Read())
				{
					LocalDocketItem newItem = new LocalDocketItem();
					newItem.product_code = Convert.ToInt32(itemDataReader["ID"]).ToString();
					newItem.product_barcode = (string)itemDataReader["ItemLookupCode"];
					newItem.sale_inc = (Decimal)itemDataReader["price"];
					newItem.quantity = (Double)itemDataReader["quantity"];
					newItem.description = (string)itemDataReader["description"];
                         newItem.department = (string)itemDataReader["department"];
                         newItem.category = (string)itemDataReader["category"];
                         newItem.cost_ex = (Decimal)itemDataReader["Cost"];
                         newItem.sale_ex = (Decimal)itemDataReader["sale_ex"];

                         
                         tempArray.Add(newItem);
				}

				itemDataReader.Close();

				latestDocket.itemList = tempArray.ToArray();

				if (customer_id > 0)
				{
					try
					{
						LocalCustomer newCustomer = new LocalCustomer();

						//Get customer.
						selectCommand.CommandText = @"SELECT ID, LastName, FirstName, Title, PhoneNumber, EmailAddress, ZIP, City, AccountNumber 
                                                            FROM Customer 
                                                            WHERE ID= " + customer_id.ToString();
						SqlDataReader customerDataReader = selectCommand.ExecuteReader(CommandBehavior.SingleRow);

						while (customerDataReader.Read())
						{							
                                   newCustomer.customer_id = (int)customerDataReader["ID"];
							newCustomer.last_name = (string)customerDataReader["LastName"];
							newCustomer.first_name = (string)customerDataReader["FirstName"];
							newCustomer.title = (string)customerDataReader["Title"];
							newCustomer.mobile = (string)customerDataReader["PhoneNumber"];
							newCustomer.email = (string)customerDataReader["EmailAddress"];
							newCustomer.suburb = (string)customerDataReader["City"];
							newCustomer.postcode = (string)customerDataReader["ZIP"];
							newCustomer.phone = (string)customerDataReader["PhoneNumber"];

							newCustomer.grade = "Default";
							newCustomer.barcode_id = (string)customerDataReader["AccountNumber"];

						}
						latestDocket.localCustomer = newCustomer;
						customerDataReader.Close();
					}
					catch (Exception ex)
					{
						throw;
					}
				}

				connection.Close();
			}
			catch (Exception ex)
			{
				throw;
			}

			return latestDocket;
		}
		
		public static List<LocalDocket> GetUnsentDockets()
		{
			string RMDBLocation = Properties.Settings.Default.RMDBLocation;
			string DPDBLocation = Properties.Settings.Default.DPDBLocation;
			List<LocalDocket> unsentDockets = RewardsHelper.GetStoredDockets();
			
			try
			{			
				//Hydrate each local docket from the Dynamics Database
				foreach (LocalDocket item in unsentDockets)
				{
					var tempItem = GetLocalDocket(item.local_id);
					item.total = tempItem.total;
					item.itemList = tempItem.itemList;
					item.localCustomer = tempItem.localCustomer;
					item.creation_datetime = tempItem.creation_datetime;
				}
			}
			catch
			{
				throw;
			}
			return unsentDockets;
		}

		public static List<LocalCustomer> GetRecentlyModifiedCustomers()
		{
			DateTime lastSync = RewardsHelper.GetLastSync();

			List<LocalCustomer> modifiedCustomers = new List<LocalCustomer>();

			if (lastSync != DateTime.MinValue)
			{
				try
				{
					// create a connection object
					SqlConnection connection = new SqlConnection(MakeConnectionString(Properties.Settings.Default.POSServerLocation,
																		 Properties.Settings.Default.POSServerDBName,
																		 Properties.Settings.Default.POSServerUser,
																		 Properties.Settings.Default.POSServerPassword));

					// create a command object
					SqlCommand selectCommand = connection.CreateCommand();
					
					connection.Open();
									
					//Get customers.
					

					//Get customer.
					selectCommand.CommandText = String.Format("SELECT ID, LastName, FirstName, Title, PhoneNumber, EmailAddress, ZIP, City, AccountNumber from Customer where LastUpdated > '{0}'", lastSync.ToString("yyyy-MM-dd HH:mm:ss"));
					SqlDataReader customerDataReader = selectCommand.ExecuteReader();

					if(customerDataReader.HasRows)
					{
						while (customerDataReader.Read())
						{
							LocalCustomer modifiedCustomer = new LocalCustomer();
							
                                   modifiedCustomer.customer_id = (int)customerDataReader["ID"];
							modifiedCustomer.last_name = (string)customerDataReader["LastName"];
							modifiedCustomer.first_name = (string)customerDataReader["FirstName"];
							modifiedCustomer.title = (string)customerDataReader["Title"];
							modifiedCustomer.mobile = (string)customerDataReader["PhoneNumber"];
							modifiedCustomer.email = (string)customerDataReader["EmailAddress"];
							modifiedCustomer.suburb = (string)customerDataReader["City"];
							modifiedCustomer.postcode = (string)customerDataReader["ZIP"];
							modifiedCustomer.phone = (string)customerDataReader["PhoneNumber"];
							modifiedCustomer.grade = "Default";
							modifiedCustomer.barcode_id = (string)customerDataReader["AccountNumber"];

							modifiedCustomers.Add(modifiedCustomer);
						}						
					}
					customerDataReader.Close();
					connection.Close();
				}
				catch (Exception ex)
				{
					throw;
				}
			}
			RewardsHelper.CreateSyncTimestamp();
			return modifiedCustomers;
		}		
	}
}
