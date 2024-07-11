export function Task() {
    return (
        <div>
            <div className="collapse collapse-plus bg-base-200">
                <input type="radio" name="my-accordion-3" defaultChecked />
                <div className="collapse-title text-xl font-medium">Inbox</div>
                <div className="collapse-content">
                    <li>
                        <ol>Task</ol>
                    </li>
                </div>
            </div>
            <div className="collapse collapse-plus bg-base-200">
                <input type="radio" name="my-accordion-3" />
                <div className="collapse-title text-xl font-medium">Home</div>
                <div className="collapse-content">
                    <li>
                        <ol>Task</ol>
                    </li>
                </div>
            </div>
        </div>
    );
}
