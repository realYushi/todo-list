export default interface ITask {
  taskId: string
  title: string
  description: string
  dueDate: string
  listId: string
  status: StatusEnum
}
enum StatusEnum {
  Pending = 1,
  InProgress = 2,
  Completed = 3,
}
