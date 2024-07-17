export default function TaskItemInput({ onClose }: { onClose: any }) {
  return (
    <div className="absolute rounded-lg bg-neutral-50">
      <div className="label">
        <span className="label-text">Task Description</span>
        <span className="label-text-alt">Required</span>
      </div>
      <input
        type="text"
        className="input input-bordered input-secondary w-full"
      />
      <div className="label">
        <span className="label-text">Task Description</span>
        <span className="label-text-alt">Optional</span>
      </div>
      <textarea className="textarea textarea-bordered w-full"></textarea>
      <div className="label">
        <span className="label-text">Due Date</span>
        <span className="label-text-alt">Optional</span>
      </div>
      <div className="flex items-center">
        <input type="date" className="input input-bordered w-full" />
      </div>
      <div className="mt-5">
        <button className="btn btn-primary w-1/2">Confirm</button>
        <button className="btn btn-warning w-1/2" onClick={() => onClose()}>
          Close
        </button>
      </div>
    </div>
  );
}
