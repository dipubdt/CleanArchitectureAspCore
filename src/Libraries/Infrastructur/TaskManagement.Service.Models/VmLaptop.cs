using HomeWork.Shared;

namespace HomeWork.Service.Models;

public class VmLaptop:IVM
{
	public int Id { get; set; }


	/// <summary>
	/// Model Name
	/// </summary>
	public string Model { get; set; } = string.Empty;


	/// <summary>
	/// ScreenSizeInches
	/// </summary>
	public string ScreenSizeInches { get; set; }

	/// <summary>
	/// RAMSizeGB
	/// </summary>
	public int RAMSizeGB { get; set; }
	/// <summary>
	/// Color
	/// </summary>
	public string Color { get; set; } = string.Empty;




}