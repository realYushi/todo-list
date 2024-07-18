export default interface ITask {
  taskId: string;
  title: string;
  description: string;
  dueDate: string;
  listId: string;
  status: "Pending" | "InProgress" | "Completed";
}
