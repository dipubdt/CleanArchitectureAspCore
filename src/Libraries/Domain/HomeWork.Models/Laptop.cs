using HomeWork.Shared;
using System.Runtime.Serialization;

namespace HomeWork.Models;
public class Laptop: BaseEntity, IEntity
{
	/// <summary>
	/// Model Name
	/// </summary>
	public string Model { get; set; }= string.Empty;


	/// <summary>
	/// ScreenSizeInches
	/// </summary>
	public string  ScreenSizeInches { get; set; }

	/// <summary>
	/// RAMSizeGB
	/// </summary>
	public int RAMSizeGB { get; set; }
	/// <summary>
	/// Color
	/// </summary>
	public string  Color  { get; set; }= string.Empty;

	public int Id { get ; set; }
}