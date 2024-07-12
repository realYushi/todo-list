import React from "react";

interface CardProps {
    title: string;
    icon: React.ReactNode;
    number: number | string;
}

export function Card({ title, icon, number }: CardProps) {
    return (
        <div className="card bg-base-100 shadow-xl m-4">
            <div className="card-body">
                <div className="flex justify-between items-center">
                    <h2 className="card-title">{title}</h2>
                    <div>{icon}</div>
                </div>
                <p className="text-lg font-bold">{number}</p>
            </div>
        </div>
    );
}

interface OverviewCardProps {
    totalNumber: number;
}

export function OverviewCard({ totalNumber }: OverviewCardProps) {
    return (
        <div className="card bg-base-100 shadow-xl m-4">
            <div>
                <div className="stat">
                    <div className="stat-figure text-secondary">
                        <div className="avatar online">
                            <div className="w-16 rounded-full">
                                <img src="https://img.daisyui.com/images/stock/photo-1534528741775-53994a69daeb.jpg" />
                            </div>
                        </div>
                    </div>
                    <div className="stat-value">{totalNumber}%</div>
                    <div className="stat-title">Tasks done</div>
                    <div className="stat-desc text-secondary">
                        31 tasks remaining
                    </div>
                </div>
            </div>
        </div>
    );
}
