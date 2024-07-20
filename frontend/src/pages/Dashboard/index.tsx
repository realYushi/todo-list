import { Card, OverviewCard } from "@pages/Dashboard/DashboardCard";
import {
  faCheckCircle,
  faHourglassHalf,
  faExclamationTriangle,
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useSelector } from "react-redux";
import { RootState } from "@store/store";

export function Dashboard() {
  const tasks = useSelector((state: RootState) => state.task.tasks);

  const doneCount = tasks.filter((task) => task.status === "Completed").length;
  const inProgressCount = tasks.filter(
    (task) => task.status === "InProgress",
  ).length;

  const overdueCount = tasks.filter(
    (task) =>
      new Date(task.dueDate) <=
        new Date(new Date().setDate(new Date().getDate() - 1)) &&
      task.status !== "Completed",
  ).length;

  return (
    <div className="flex justify-center">
      <section className="w-full grid-cols-2 lg:grid lg:w-3/4">
        <OverviewCard
          tasks={tasks}
          avatar="https://avataaars.io/?avatarStyle=Transparent&topType=NoHair&accessoriesType=Round&facialHairType=Blank&clotheType=BlazerShirt&eyeType=Wink&eyebrowType=UpDownNatural&mouthType=Twinkle&skinColor=Pale"
        />
        <Card
          title="Done"
          icon={<FontAwesomeIcon icon={faCheckCircle} size="lg" />}
          number={doneCount}
        />
        <Card
          title="In Progress"
          icon={<FontAwesomeIcon icon={faHourglassHalf} size="lg" />}
          number={inProgressCount}
        />
        <Card
          title="Overdue"
          icon={<FontAwesomeIcon icon={faExclamationTriangle} size="lg" />}
          number={overdueCount}
        />
      </section>
    </div>
  );
}
