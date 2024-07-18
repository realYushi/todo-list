import task from "./TaskInterface";
export default interface IList {
  listId: string | null;
  title: string;
  description: string;
  tasks: task[];
  createdAt?: string;
  updatedAt?: string;
}
