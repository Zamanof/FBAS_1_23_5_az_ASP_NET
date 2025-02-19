import React from "react";
import './status-filter.css'
const StatusFilter=({active, text})=>{
    const clazz = active
        ? "btn btn-info btn-outline-secondary"
        : "btn btn-outline-secondary"
    return (
        <button type={"button"} className={clazz}>
            {text}
        </button>
    )
}
export default StatusFilter