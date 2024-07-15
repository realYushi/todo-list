import { NewList } from "@pages/Task/TaskNewList";
import TaskController from "./TaskContainer";
export function Task() {
  return (
    <div className="lg:flex-wrap">
      <TaskController />
      <NewList />
    </div>
  );
}
