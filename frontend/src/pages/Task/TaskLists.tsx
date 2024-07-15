import IList from "@modelsListInterface";
import TaskList from "./TaskList";
import ITask from "@modelsTaskInterface";

interface ListsProps {
  lists: IList[];
  tasks: ITask[];
}

export default function TaskLists({ lists, tasks }: ListsProps) {
  return (
    <div className="justify-center gap-12 lg:flex">
      {lists.map((list) => (
        <TaskList key={list.listId} list={list} tasks={tasks} />
      ))}
    </div>
  );
}
