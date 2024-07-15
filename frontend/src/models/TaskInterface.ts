export default interface ITask {
  taskId: string;
  title: string;
  description: string;
  dueDate: Date;
  listId: string;
  status: "Pending" | "InProgress" | "Completed";
}
