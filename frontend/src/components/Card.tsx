import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faCalendarAlt, faFire } from "@fortawesome/free-solid-svg-icons";

interface CardProps {
    title: string;
    icon: React.ReactNode;
    number: number | string;
}

export function Card({ title, icon, number }: CardProps) {
    return (
        <div className="grid grid-rows-2">
            <div className="grid grid-cols-2">
                <h2>{title}</h2>
                <div className="justify-self-end">{icon}</div>
            </div>
            <p>{number}</p>
        </div>
    );
}

interface OverviewCardProps {
    number: number;
}

export function OverviewCard({ number }: OverviewCardProps) {
    return (
        <div>
            <div className="grid grid-cols-2">
                <h2>Overview</h2>
                <FontAwesomeIcon
                    icon={faCalendarAlt}
                    className="justify-self-end"
                />
            </div>
            <div className="grid">
                <p>{number}</p>
                <div className="grid grid-cols-3">
                    <p>Streak</p>
                    <FontAwesomeIcon
                        icon={faFire}
                        className="justify-self-center"
                    />
                    <p className="justify-self-end">7 days</p>
                </div>
            </div>
        </div>
    );
}
