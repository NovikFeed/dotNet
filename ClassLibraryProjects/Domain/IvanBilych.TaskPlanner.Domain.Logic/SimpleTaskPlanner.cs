using IvanBilych.TaskPlanner.Domain.Models;
using IvanBilych.TaskPlanner.DataAccess.Abstractions;

namespace IvanBilych.TaskPlanner.Domain.Logic;


public class SimpleTaskPlanner
{
  public WorkItem[] CreatePlan(IWorkItemsRepository fileWorkItemsRepository)
  {
    List<WorkItem> workItemList = fileWorkItemsRepository.GetAll().ToList();

    workItemList.Sort((x, y) =>
        {
          int priorityComparison = y.Priority.CompareTo(x.Priority);
          if (priorityComparison != 0)
            return priorityComparison;

          int dueDateComparison = x.DueDate.CompareTo(y.DueDate);
          if (dueDateComparison != 0)
            return dueDateComparison;

          return string.Compare(x.Title, y.Title, StringComparison.OrdinalIgnoreCase);
        });

    return workItemList.Where(x => x.IsCompleted is false).ToArray();
  }
}

