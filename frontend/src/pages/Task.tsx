import { Lists } from "../components/Task/Lists";
import { NewList } from "../components/Task/NewList";
export function Task() {
  return (
    <div className="lg:flex-wrap">
      <Lists />
      <NewList />
    </div>
  );
}
