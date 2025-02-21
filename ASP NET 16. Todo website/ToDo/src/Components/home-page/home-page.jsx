import {Link} from "react-router-dom";

const HomePage = () => {
    return (
        <div>
            <h1>ToDo</h1>
            <Link to="/register">Register</Link>
            <br/>
            <Link to="/login">Login</Link>
        </div>
    )
}
export default HomePage