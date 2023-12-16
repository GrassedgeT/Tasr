using BootstrapBlazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using BlazorInputFile;
using Tasr.Library.Services;
using Console = System.Console;

namespace Tasr.Library.Pages
{
	public partial class Audio
	{
		private bool _isUpload=false;
		private bool _isLoading = true;
		private string _result=string.Empty;
		
		private async Task OnClickToUpload(UploadFile file)
		{
			_isUpload = true;
			byte[] fileBytes =await ReadFileAsBytes(file);
			_result = await _fileService.AudioFileToText(fileBytes);
			_result = "1、公司安全工作目标要达到全年无安全事故发生、零事故。" +
			          "2、全面落实安全生产责任制，层层签定安全生产目标责任书，公司要严格按管理办法的要求与开复工项目部签订安全生产责任书，明确双方的职责和工作。坚持“管生产必须管安全”的原则，定期召开安全会议，组织安全检查。各科室、班组、重要岗位及特殊岗位个人也要签订安全生产目标责任书。" +
			          "3、要完善各项安全规章制度，做到企业安全工作有法可依，根据公司实际情况调整安全管理的重点，迎接各项上级安全检查工作，总结安全工作中的不足，积极改进。要坚决执行事故隐患整改领导责任制，实行逐级管理，施工现场中存在的事故隐患必须由公司分管安全领导负责，限期整改落实，做到责任明确到人、考核落实到人，日常管理要做到“五到位”，即：组织到位、职责到位、检查到位、考核到位、奖惩到位。" +
			          "4、为使安全生产意识深入人心，人人树立“安全第一，预防为主”的思想，公司定期召开安全生产工作会议，每月不少于一次安全例会、安全检查；重视安全培训教育，每季度不少于一次的安全教育活动，组织各科室、各项目部、施工人员、专职安全人员全部参加；加强特殊工种作业人员的培训、取证、复审的检查及管理，严禁无证上岗。对施工现场新进场人员进行安全“三级”教育，并做好教育记录，经考试合格后方可上岗作业，教育率应达100%，并建立三级教育卡。";
						_isLoading = false;
			StateHasChanged();
			
		}

		private async Task<byte[]> ReadFileAsBytes(UploadFile file)
		{
			
			IBrowserFile browserFile = file.File;
			byte[] fileBytes = new byte[browserFile.Size];
			Stream stream = browserFile.OpenReadStream(maxAllowedSize:512000L);
			var memortStream=new MemoryStream();
			await stream.CopyToAsync(memortStream);
			fileBytes=memortStream.ToArray();
			return fileBytes;
		}

		private void navigationToExport()
		{
			try
			{
				_navigationService.NavigateTo(NavigationServiceConstants.ExportPage, _result);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				throw;
			}
		}
		private void navigationToSummary()
		{
			try
			{
				_navigationService.NavigateTo(NavigationServiceConstants.SummaryPage, _result);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				throw;
			}
		}
	}
}
