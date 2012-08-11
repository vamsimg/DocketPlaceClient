using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using DocketPlaceClient.au.com.docketplace;
using System.Text.RegularExpressions;

namespace DocketPlaceClient
{
	public class MYOBRewards
	{
		
		private static bool CheckIfTaxInvoice(string receipt_content)
		{
			string[] lines = Regex.Split(receipt_content, "\n");

			bool isTaxInvoice = false;
			foreach (string line in lines)
			{
				isTaxInvoice = line.Contains("Tax Invoice");
				if (isTaxInvoice)
				{
					return isTaxInvoice;
				}
			}
			return isTaxInvoice;
		}

		private static int ExtractDocketID(string receipt_content)
		{
			string[] lines = Regex.Split(receipt_content, "\n");

			int index = 0;
			string docketLine = "";
			foreach (string line in lines)
			{
				index++;
				if (line.Contains("Docket"))
				{
					docketLine = lines[index];
				}
			}

			string[] lineItems = docketLine.Split(' ');
			int docket_id = Convert.ToInt32(lineItems[0]);

			return docket_id;
		}

		public static LocalDocket GetLastDocket(string receipt_content)
		{			
			if (!CheckIfTaxInvoice(receipt_content))
			{
				return null;
			}
			else
			{
				int docket_id = ExtractDocketID(receipt_content);

                    LocalDocket latestDocket = GetLocalDocket(docket_id);

				return latestDocket;
			}
		}

          private static LocalDocket GetLocalDocket(int docket_id)
          {
               string RMDBLocation = Properties.Settings.Default.RMDBLocation;
               LocalDocket latestDocket = new LocalDocket();

               try
               {
                    OleDbConnection RMDBconnection = null;
                    OleDbDataReader dbReader = null;

                    RMDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + RMDBLocation);
                    RMDBconnection.Open();

                    OleDbCommand docketCmd = RMDBconnection.CreateCommand();
                    //Get latest transaction.
                    docketCmd.CommandText = "SELECT docket_id, docket_date, customer_id ,total_inc from Docket where docket_id = " + docket_id.ToString();
                    dbReader = docketCmd.ExecuteReader();


                    int customer_id = 0;
                    while (dbReader.Read())
                    {
                         latestDocket.local_id = (int)dbReader.GetValue(0);
                         latestDocket.creation_datetime = (DateTime)dbReader.GetValue(1);
                         customer_id = (int)dbReader.GetValue(2);
                         latestDocket.total = (Decimal)dbReader.GetValue(3);
                    }

                    dbReader.Close();

                    //Get docket items for transaction.
                    if (Properties.Settings.Default.CategoriesOnly)
                    {
                         docketCmd.CommandText = @"SELECT Stock.stock_id, Stock.Barcode  , sell_inc , DocketLine.quantity, Stock.description, cost_ex, sell_ex, cat1, cat2 
                                                   FROM DocketLine 
                                                   INNER JOIN Stock ON DocketLine.stock_id = Stock.stock_id 
                                                   WHERE docket_id=" + latestDocket.local_id.ToString();
                    }
                    else
                    {
                         docketCmd.CommandText = @"SELECT Stock.stock_id, Stock.Barcode  , sell_inc , DocketLine.quantity, Stock.description, cost_ex, sell_ex, dept_name, cat1 
                                                   FROM (DocketLine INNER JOIN Stock ON DocketLine.stock_id = Stock.stock_id)
                                                   INNER JOIN Departments on Stock.dept_id = Departments.dept_id 
                                                   WHERE docket_id=" + latestDocket.local_id.ToString();
                    }
                    
                    dbReader = docketCmd.ExecuteReader();
                    List<LocalDocketItem> tempArray = new List<LocalDocketItem>();

                    while (dbReader.Read())
                    {
                         LocalDocketItem newItem = new LocalDocketItem();
                         newItem.product_code = dbReader.GetValue(0).ToString();
                         newItem.product_barcode = dbReader.GetValue(1).ToString();
                         newItem.sale_inc = (Decimal)dbReader.GetValue(2);
                         newItem.quantity = (Double)dbReader.GetValue(3);
                         newItem.description = (string)dbReader.GetValue(4);
                         

                         newItem.cost_ex = (Decimal)dbReader.GetValue(5);
                         newItem.sale_ex = (Decimal)dbReader.GetValue(6);

                         newItem.department = (string)dbReader.GetValue(7);
                         newItem.category = (string)dbReader.GetValue(8);

                         tempArray.Add(newItem);
                    }

                    latestDocket.itemList = tempArray.ToArray();

                    if (customer_id > 0)
                    {
                         try
                         {
                              LocalCustomer newCustomer = new LocalCustomer();


                              OleDbCommand CustomerCmd = RMDBconnection.CreateCommand();
                              //Get customer.
                              CustomerCmd.CommandText = @"SELECT customer_id, surname, given_names, salutation, mobile, email, postcode, phone, grade, barcode,suburb  
                                                          FROM Customer 
                                                          WHERE customer_id = " + customer_id.ToString();
                              dbReader = CustomerCmd.ExecuteReader();

                              while (dbReader.Read())
                              {
                                   int tempCustomerID = (int)dbReader.GetValue(0);
                                   newCustomer.customer_id = tempCustomerID.ToString();
                                   newCustomer.last_name = (string)dbReader.GetValue(1);
                                   newCustomer.first_name = (string)dbReader.GetValue(2);
                                   newCustomer.title = (string)dbReader.GetValue(3);
                                   newCustomer.mobile = (string)dbReader.GetValue(4);
                                   newCustomer.email = (string)dbReader.GetValue(5);
                                   newCustomer.suburb = (string)dbReader.GetValue(10);
                                   newCustomer.postcode = (string)dbReader.GetValue(6);
                                   newCustomer.phone = (string)dbReader.GetValue(7);

                                   Int16 grade = (Int16)dbReader.GetValue(8);
                                   switch (grade)
                                   {
                                        case 0:
                                             newCustomer.grade = "Default";
                                             break;
                                        case 1:
                                             newCustomer.grade = "A";
                                             break;
                                        case 2:
                                             newCustomer.grade = "B";
                                             break;
                                        case 3:
                                             newCustomer.grade = "C";
                                             break;
                                        case 4:
                                             newCustomer.grade = "D";
                                             break;
                                        default:
                                             newCustomer.grade = "Default";
                                             break;
                                   }
                                   newCustomer.barcode_id = (string)dbReader.GetValue(9);

                              }
                              latestDocket.localCustomer = newCustomer;
                              dbReader.Close();
                         }
                         catch (Exception ex)
                         {
                              throw;
                         }
                    }

                    RMDBconnection.Close();
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

			List<LocalDocket> unsentDockets = RewardsHelper.GetStoredDockets();

			try
			{
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
			string RMDBLocation = Properties.Settings.Default.RMDBLocation;
			DateTime lastSync = RewardsHelper.GetLastSync();

			List<LocalCustomer> modifiedCustomers = new List<LocalCustomer>();

			if (lastSync != DateTime.MinValue)
			{
				try
				{
					OleDbConnection RMDBconnection = null;
					OleDbDataReader dbReader = null;

					RMDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + RMDBLocation);
					RMDBconnection.Open();

					OleDbCommand SyncCmd = RMDBconnection.CreateCommand();
					//Get customers.
					string commandText = "SELECT customer_id, surname, given_names, salutation, mobile, email, postcode, phone, grade, barcode,suburb , date_modified from Customer where date_modified > #$lastSync#";

					commandText = commandText.Replace("$lastSync", lastSync.ToString("yyyy-MM-dd HH:mm:ss"));
					SyncCmd.CommandText = commandText;

					dbReader = SyncCmd.ExecuteReader();

					if (dbReader.HasRows)
					{
						while (dbReader.Read())
						{
							DateTime modify = (DateTime)dbReader.GetValue(11);

							LocalCustomer newCustomer = new LocalCustomer();
							int tempCustomerID = (int)dbReader.GetValue(0);
							newCustomer.customer_id = tempCustomerID.ToString();
							newCustomer.last_name = (string)dbReader.GetValue(1);
							newCustomer.first_name = (string)dbReader.GetValue(2);
							newCustomer.title = (string)dbReader.GetValue(3);
							newCustomer.mobile = (string)dbReader.GetValue(4);
							newCustomer.email = (string)dbReader.GetValue(5);
							newCustomer.suburb = (string)dbReader.GetValue(10);
							newCustomer.postcode = (string)dbReader.GetValue(6);
							newCustomer.phone = (string)dbReader.GetValue(7);

							Int16 grade = (Int16)dbReader.GetValue(8);
							switch (grade)
							{
								case 0:
									newCustomer.grade = "Default";
									break;
								case 1:
									newCustomer.grade = "A";
									break;
								case 2:
									newCustomer.grade = "B";
									break;
								case 3:
									newCustomer.grade = "C";
									break;
								case 4:
									newCustomer.grade = "D";
									break;
								default:
									newCustomer.grade = "Default";
									break;
							}
							newCustomer.barcode_id = (string)dbReader.GetValue(9);
							modifiedCustomers.Add(newCustomer);
						}
					}

					dbReader.Close();
					RMDBconnection.Close();
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
