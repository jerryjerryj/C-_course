using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Failures
{
	public class Device
	{
		public Device(int id, string name)
		{
			Id = id;
			Name = name;
		}
		public int Id { get; set; }
		public string Name{ get; set; }
}
	public class ReportMaker
	{
		public enum FailureType { Serious, NotSerious };
		public static FailureType IsFailureSerious(int failureType)
		{
			if (failureType % 2 == 0) return FailureType.Serious;
			return FailureType.NotSerious;
		}
		public static bool Earlier(DateTime v, int day, int month, int year)
		{
			if (v.Year < year) return true;
			if (v.Year > year) return false;
			if (v.Month < month) return true;
			if (v.Month > month) return false;
			if (v.Day < day) return true;
			return false;
		}

		public static List<string> FindDevicesFailedBeforeDate(
			DateTime dmy,
			FailureType[] failures,
			DateTime[] times,
			Device[] devices)
		{
			var problematicDevices = new HashSet<int>();
			for (int i = 0; i < failures.Length; i++)
				if (failures[i] == FailureType.Serious && Earlier(times[i], dmy.Day, dmy.Month, dmy.Year))
					problematicDevices.Add(i);

			var result = new List<string>();
			foreach (var device in devices)
				if (problematicDevices.Contains(device.Id))
					result.Add(device.Name);

			return result;
		}

		public static List<string> FindDevicesFailedBeforeDateObsolete(
			int day,
			int month,
			int year,
			int[] failureTypes,
			int[] deviceId,
			object[][] times,
			List<Dictionary<string, object>> devices)
		{
			var date = new DateTime(year,month,day);
			var failures = failureTypes.Select(f => IsFailureSerious(f)).ToArray();
			var dates = Array.ConvertAll(times, t => new DateTime((int)t[2], (int)t[1], (int)t[0] ));
			var devs = devices.Select(x => new Device((int)x["DeviceId"],(string)x["Name"])).ToArray();
			return FindDevicesFailedBeforeDate(date, failures, dates, devs);
			
			
        }
           
    }
}
