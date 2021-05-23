using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LocalizationDataAnnotation.Models
{
	public class UserViewModel
	{
		[Required(ErrorMessage = "Validate_Required")]
		[Display(Name = "ID_DisplayName")]
		[StringLength(20, ErrorMessage = "Validate_StringLength")]
		[RegularExpression(@"^[0-9a-zA-Z]*$", ErrorMessage = "Validate_Alphanumeric")]
		public string ID { get; set; }

		[Display(Name = "Name_DisplayName")]
		[StringLength(50, ErrorMessage = "Validate_StringLength")]
		public string Name { get; set; }

		[Display(Name = "Password_DisplayName")]
		[StringLength(50, MinimumLength = 8, ErrorMessage = "Validate_StringLengthRange")]
		[DataType(DataType.Password)]
		[RegularExpression(@"^[0-9a-zA-Z]*$", ErrorMessage = "Validate_Alphanumeric")]
		public string Password { get; set; }

		[Display(Name = "ConfirmPassword_DisplayName")]
		[StringLength(50, MinimumLength = 8, ErrorMessage = "Validate_StringLengthRange")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Validate_Compare")]
		public string ConfirmPassword { get; set; }

		[Display(Name = "Email_DisplayName")]
		[EmailAddress(ErrorMessage = "Validate_EmailAddress")]
		[DataType(DataType.EmailAddress)] // スキャフォールディングするときはコメントアウトする
		public string Email { get; set; }

		[Display(Name = "Age_DisplayName")]
		[Required(ErrorMessage = "Validate_Required")]
		[Range(0, 150, ErrorMessage = "Validate_Range")]
		public int Age { get; set; }

		[Display(Name = "Gender_DisplayName")]
		[Required(ErrorMessage = "Validate_Required")]
		[EnumDataType(typeof(GenderType))]
		public GenderType Gender { get; set; }

		[Display(Name = "Birthday_DisplayName")]
		[DataType(DataType.Date)]
		public DateTime Birthday { get; set; }

		[Display(Name = "Phone_DisplayName")]
		[Phone(ErrorMessage = "Validate_Phone")]
		[DataType(DataType.PhoneNumber)] // スキャフォールディングするときはコメントアウトする
		public string Phone { get; set; }

		[Display(Name = "PostalCode_DisplayName")]
		[DataType(DataType.PostalCode)]
		public string PostalCode { get; set; }

		[Display(Name = "CreditCard_DisplayName")]
		[CreditCard(ErrorMessage = "Validate_CreditCard")]
		[DataType(DataType.CreditCard)] // スキャフォールディングするときはコメントアウトする
		public string CreditCard { get; set; }

		[Display(Name = "Money_DisplayName")]
		[DataType(DataType.Currency)]
		public decimal Money { get; set; }

		[Display(Name = "StartDateTime_DisplayName")]
		[DataType(DataType.DateTime)]
		public DateTime StartDateTime { get; set; }

		[Display(Name = "WakeUpTime_DisplayName")]
		[DataType(DataType.Time)]
		public TimeSpan WakeUpTime { get; set; }

		[Display(Name = "Homepage_DisplayName")]
		[Url(ErrorMessage = "Validate_Url")]
		[DataType(DataType.Url)] // スキャフォールディングするときはコメントアウトする
		public string Homepage { get; set; }

		[Display(Name = "MyImage_DisplayName")]
		[Url(ErrorMessage = "Validate_Url")]
		[DataType(DataType.ImageUrl)] // スキャフォールディングするときはコメントアウトする
		public string MyImage { get; set; }

		[Display(Name = "MyColor_DisplayName")]
		public string MyColor { get; set; }

		[Display(Name = "WorkingDays_DisplayName")]
		[MaxLength(5, ErrorMessage = "Validate_MaxLength")]
		[EnumDataType(typeof(DayOfWeek))]
		public DayOfWeek[] WorkingDays { get; set; }

		[Display(Name = "VacationDay_DisplayName")]
		[MinLength(3, ErrorMessage = "Validate_MinLength")]
		[EnumDataType(typeof(DayOfWeek))]
		public DayOfWeek[] VacationDay { get; set; }

		[Display(Name = "Comment_DisplayName")]
		[StringLength(200, ErrorMessage = "Validate_StringLength")]
		[DataType(DataType.MultilineText)]
		public string Comment { get; set; }

		[Display(Name = "FileName_DisplayName")]
		[FileExtensions(Extensions = "png", ErrorMessage = "Validate_FileExtensions")]
		public string FileName { get; set; }

		[Display(Name = "UploadFile_DisplayName")]
		[DataType(DataType.Upload)]
		public List<IFormFile> UploadFile { get; set; }

		[Display(Name = "Month_DisplayName")]
		public DateTime Month { get; set; }

		[Display(Name = "Search_DisplayName")]
		public string Search { get; set; }

		[Display(Name = "Range_DisplayName")]
		[Range(10, 100, ErrorMessage = "Validate_Range")]
		public int Range { get; set; }

		[Display(Name = "Week_DisplayName")]
		public string Week { get; set; }

		[Display(Name = "IsAccepted_DisplayName")]
		[Required(ErrorMessage = "Validate_Required")]
		public bool IsAccepted { get; set; }
	}

	public enum GenderType
	{
		None,
		Man,
		Woman,
		Other,
	}
}
