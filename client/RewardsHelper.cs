using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using DocketPlaceClient.au.com.docketplace;

namespace DocketPlaceClient
{
	class RewardsHelper
	{
		public static void SaveLastDocket(LocalDocket currentDocket)
		{
			string DPDBLocation = Properties.Settings.Default.DPDBLocation;
			try
			{
				OleDbConnection DPDBconnection = null;


				DPDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + DPDBLocation);
				DPDBconnection.Open();

				OleDbCommand docketCmd = DPDBconnection.CreateCommand();

				string commandText = @"INSERT INTO Dockets (docket_id, docket_date, raw_content) 
								 VALUES ($docket_id, $docket_date,$raw_content)";

				commandText = commandText.Replace("$docket_id", currentDocket.local_id.ToString());
				commandText = commandText.Replace("$docket_date", "'" + currentDocket.creation_datetime.ToString() + "'");
				commandText = commandText.Replace("$raw_content", "'" + currentDocket.receipt_content + "'");

				//Save latest transaction.
				docketCmd.CommandText = commandText;
				int numRowsAffected = docketCmd.ExecuteNonQuery();
				DPDBconnection.Close();
			}
			catch
			{
				throw;
			}

		}

		public static List<LocalDocket> GetStoredDockets()
		{
			string DPDBLocation = Properties.Settings.Default.DPDBLocation;
			List<LocalDocket> unsentDockets = new List<LocalDocket>();
			try
			{
				OleDbConnection DPDBconnection = null;
				OleDbDataReader DPdbReader = null;

				DPDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + DPDBLocation);
				DPDBconnection.Open();

				OleDbCommand DPdocketCmd = DPDBconnection.CreateCommand();
				//Get latest transaction.
				DPdocketCmd.CommandText = "SELECT docket_id, raw_content from Dockets";
				DPdbReader = DPdocketCmd.ExecuteReader();



				while (DPdbReader.Read())
				{
					LocalDocket latestDocket = new LocalDocket();
					latestDocket.local_id = (int)DPdbReader.GetValue(0);
					latestDocket.receipt_content = (string)DPdbReader.GetValue(1);
					unsentDockets.Add(latestDocket);
				}

				DPdbReader.Close();

				DPDBconnection.Close();
			}
			catch
			{
				throw;
			}
			return unsentDockets;
		}
		
		public static void CreateSyncTimestamp()
		{
			string DPDBLocation = Properties.Settings.Default.DPDBLocation;
			try
			{
				OleDbConnection DPDBconnection = null;


				DPDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + DPDBLocation);
				DPDBconnection.Open();

				OleDbCommand syncCmd = DPDBconnection.CreateCommand();

				string commandText = @"INSERT INTO Syncs (sync_datetime) 
								 VALUES (#$latestSync#)";

				commandText = commandText.Replace("$latestSync", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

				//Save latest sync.
				syncCmd.CommandText = commandText;
				int numRowsAffected = syncCmd.ExecuteNonQuery();
				DPDBconnection.Close();
			}
			catch
			{
				throw;
			}
		}

		public static void DeleteSentDocket(int local_id)
		{
			string DPDBLocation = Properties.Settings.Default.DPDBLocation;
			try
			{
				OleDbConnection DPDBconnection = null;


				DPDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + DPDBLocation);
				DPDBconnection.Open();

				OleDbCommand docketCmd = DPDBconnection.CreateCommand();

				string commandText = "Delete * from Dockets where docket_id=" + local_id.ToString();

				//Save latest transaction.
				docketCmd.CommandText = commandText;
				int numRowsAffected = docketCmd.ExecuteNonQuery();
				DPDBconnection.Close();
			}
			catch
			{
				throw;
			}
		}

		public static DateTime GetLastSync()
		{
			string DPDBLocation = Properties.Settings.Default.DPDBLocation;
			DateTime lastSync = new DateTime();

			try
			{
				OleDbConnection DPDBconnection = null;
				OleDbDataReader DPdbReader = null;

				DPDBconnection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; User Id=; Password=; Data Source=" + DPDBLocation);
				DPDBconnection.Open();

				OleDbCommand DPdocketCmd = DPDBconnection.CreateCommand();

				//Check to see if there are any rows
				DPdocketCmd.CommandText = "SELECT COUNT(*) from Syncs";

				int count = (int)DPdocketCmd.ExecuteScalar();

				if (count > 0)
				{
					DPdocketCmd.CommandText = "SELECT MAX(sync_datetime) from Syncs";

					DPdbReader = DPdocketCmd.ExecuteReader();

					if (DPdbReader.Read())
					{
						lastSync = DPdbReader.GetDateTime(0);
					}
				}
				DPDBconnection.Close();
			}
			catch
			{
				throw;
			}
			return lastSync;
		}

	}
}
