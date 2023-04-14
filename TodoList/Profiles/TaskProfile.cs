using AutoMapper;
using TodoList.Models;
using TodoList.Models.InputDTOs;

namespace TodoList.Profiles
{
	public class TaskProfile : Profile
	{
			public TaskProfile()
			{
				CreateMap<TaskInputViewModel,TaskViewModel>();
			}
	}
}
