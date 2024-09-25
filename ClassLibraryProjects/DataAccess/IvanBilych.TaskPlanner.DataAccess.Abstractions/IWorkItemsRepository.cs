namespace IvanBilych.TaskPlanner.DataAccess.Abstractions;

using System;
using IvanBilych.TaskPlanner.Domain.Models;

public interface IWorkItemsRepository
{
  Guid Add(WorkItem workItem);
  WorkItem? Get(Guid id);
  WorkItem[] GetAll();
  bool Update(WorkItem workItem);
  bool Remove(Guid id);
  void SaveChanges();
}
