import { Lists } from "@pages/Task/TaskLists";
import { NewList } from "@pages/Task/TaskNewList";
export function Task() {
  return (
    <div className="lg:flex-wrap">
      <Lists />
      <NewList />
    </div>
  );
}
