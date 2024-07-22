import { Card, OverviewCard } from "@pages/Dashboard/DashboardCard"
import {
  faCheckCircle,
  faHourglassHalf,
  faExclamationTriangle,
} from "@fortawesome/free-solid-svg-icons"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import { useGetTasksQuery } from "@servicetaskEndpoint"

export function Dashboard() {
  enum StatusEnum {
    Pending = 1,
    InProgress = 2,
    Completed = 3,
  }
  const { data: tasks, isLoading, isError } = useGetTasksQuery()

  if (isLoading) return <div>Loading...</div>
  if (isError) return <div>Error fetching tasks</div>
  if (!tasks) return <div>No tasks found</div>

  const doneCount = tasks.filter(
    task => task.status === StatusEnum.Completed,
  ).length
  const inProgressCount = tasks.filter(
    task => task.status === StatusEnum.InProgress,
  ).length
  const overdueCount = tasks.filter(
    task =>
      new Date(task.dueDate) <=
        new Date(new Date().setDate(new Date().getDate() - 1)) &&
      task.status !== StatusEnum.Completed,
  ).length

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
  )
}
