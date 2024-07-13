import React from "react";
interface CardProps {
  title: string;
  icon: React.ReactNode;
  number: number | string;
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
  );
}

interface OverviewCardProps {
  avatar: string;
  totalNumber: number;
}

export function OverviewCard({ totalNumber, avatar }: OverviewCardProps) {
  return (
    <div className="card m-4 min-h-60 justify-center bg-base-100 shadow-xl">
      <div>
        <div className="stat">
          <div className="stat-figure text-secondary">
            <div className="avatar online">
              <div className="w-16 rounded-full">
                <img src={avatar} />
              </div>
            </div>
          </div>
          <div className="stat-value">{totalNumber}%</div>
          <div className="stat-title">Tasks done</div>
          <div className="stat-desc text-secondary">31 tasks remaining</div>
        </div>
      </div>
    </div>
  );
}
