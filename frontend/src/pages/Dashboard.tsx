import { Card, OverviewCard } from "../components/Dashborad/Card";
import {
  faCheckCircle,
  faClock,
  faHourglassHalf,
  faExclamationTriangle,
} from "@fortawesome/free-solid-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export function Dashboard() {
  return (
    <div className="flex justify-center">
      <section className="w-full grid-cols-2 lg:grid lg:w-3/4">
        <OverviewCard totalNumber={1234} avatar="" />
        <Card
          title="Done"
          icon={<FontAwesomeIcon icon={faCheckCircle} size="lg" />}
          number={1234}
        />
        <Card
          title="In Progress"
          icon={<FontAwesomeIcon icon={faHourglassHalf} size="lg" />}
          number={1234}
        />
        <Card
          title="Pending"
          icon={<FontAwesomeIcon icon={faClock} size="lg" />}
          number={1234}
        />
        <Card
          title="Overdue"
          icon={<FontAwesomeIcon icon={faExclamationTriangle} size="lg" />}
          number={1234}
        />
      </section>
    </div>
  );
}
