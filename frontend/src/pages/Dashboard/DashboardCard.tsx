import React from "react"

import ITask from "@modelsTaskInterface"
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome"
import { faThumbsUp, faUser } from "@fortawesome/free-solid-svg-icons"

interface CardProps {
  title: string
  icon: React.ReactNode
  number: number | string
}
enum StatusEnum {
  Pending = 1,
  InProgress = 2,
  Completed = 3,
}
export function Card({ title, icon, number }: CardProps) {
  return (
    <div className="card m-4 min-h-40 bg-base-100 shadow-xl">
      <div className="card-body">
        <div className="flex items-center justify-between">
          <h2 className="font-medium">{title}</h2>
          <div>{icon}</div>
        </div>
        <div className="mt-4">
          <p className="text-lg font-black">{number}</p>
        </div>
      </div>
    </div>
  )
}

interface OverviewCardProps {
  tasks: ITask[]
}

export function OverviewCard({ tasks }: OverviewCardProps) {
  const totalNumber = tasks.length
  const doneTasks = tasks.filter(
    task => task.status === StatusEnum.Completed,
  ).length
  const doneTasksPercentage =
    totalNumber > 0 ? ((doneTasks / totalNumber) * 100).toFixed(0) : 0
  const remainingTasks = totalNumber - doneTasks
  return (
    <div className="card m-4 min-h-60 justify-center bg-base-100 shadow-xl">
      <div>
        <div className="stat">
          <div className="stat-figure text-secondary">
            <div className="avatar ">
              <FontAwesomeIcon className="text-5xl" icon={faUser} />
            </div>
          </div>
          <div className="stat-value">{doneTasksPercentage} %</div>
          <div className="stat-title">Tasks done</div>
          <div className="stat-desc text-secondary">
            {remainingTasks} Tasks remain
          </div>
        </div>
      </div>
    </div>
  )
}
