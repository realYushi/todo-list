import task from './TaskInterface';
export default interface IList {
  listId: string | null;
  title: string;
  description: string;
  createdAt: string;
  updatedAt: string | null;
  tasks: task[]
}
