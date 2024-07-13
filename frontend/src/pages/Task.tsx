import { List } from "../components/Task/List";
export function Task() {
  return (
    <div className="lg:flex-wrap">
      <List />
      <List />
    </div>
  );
}
