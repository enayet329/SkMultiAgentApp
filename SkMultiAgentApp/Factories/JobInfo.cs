using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkMultiAgentApp.Factories;

public class JobInfo
{
	public string Title { get; set; } = null!;
	public string Company { get; set; } = null!;
	public string Location { get; set; } = null!;
	public string Description { get; set; } = null!;
	public List<string> RequiredSkills { get; set; } = [];
	public string SalaryRange { get; set; } = null!;
	public string ApplicationUrl { get; set; } = null!;
}