import "./task-list.css"

import TaskListItem from "../task-list-item/task-list-item.jsx";
const TaskList = ({ tasks, onDeleted, onChecked }) => {
    return (
        <ul className="list-group list-todo">
            {tasks.map(({ id, ...itemProps }) => (
                <li key={id} className="list-group-item">
                    <TaskListItem
                        {...itemProps}
                        onDeleted={() => onDeleted(id)}
                        onChecked={(isComplete) => onChecked(id, isComplete)}
                    />
                </li>
            ))}
        </ul>
    );
};
export default TaskList