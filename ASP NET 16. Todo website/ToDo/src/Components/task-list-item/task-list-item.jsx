import "./task-list-item.css"
const TaskListItem = ({text, isCompleted, onChecked, onDeleted}) => {

    return(
        <span className={"todo-list-item"}>
            <span className={"todo-list-item-text"}>
                {text}
            </span>
            <button
            type={"button"}
            className={"btn btn-outline-danger btn-sm delete"}>
                Delete
            </button>
        </span>

    )
}
export default TaskListItem