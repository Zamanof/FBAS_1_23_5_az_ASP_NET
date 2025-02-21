import {useState} from "react";
import {useNavigate} from "react-router-dom";
import TodoService from "../../Services/todo-service.js";

const LoginForm=()=>{
    const service = new TodoService()
    const[email,setEmail]=useState();
    const [password,setPassword]=useState();
    const navigate=useNavigate();

    const emailChange=(e)=>{
        setEmail(e.target.value);
    }
    const passwordChange=(e)=>{
        setPassword(e.target.value);
    }
    const login = (e)=>{
       service.login(e, email,password).then((status)=>{
           if(status === 200){
               console.log(status);
               navigate('/todo');
           }

       })

    }

    return (
        <section>
            <div>
                <h1>Todo Sign In</h1>
                <form>
                    <p>
                        <label className="form-label" htmlFor={"mail"}>Email </label>
                    </p>
                    <p>
                        <input
                            id="mail" type="email" name={"email"}
                            placeholder="Email" className="form-control"
                            value={email} onChange={emailChange}
                            onInput={emailChange} onPaste={passwordChange}/>
                    </p>
                    <p>
                        <label className="form-label" htmlFor={"pass"}>Password </label>
                    </p>
                    <p>
                        <input
                            id="pass" type="password" name={"password"}
                            placeholder="Password" className="form-control"
                            value={password} onChange={passwordChange}
                            onInput={passwordChange} onPaste={passwordChange}/>
                    </p>

                    <button
                        className="btn btn-primary btn-lg" type="button"
                        onClick={login}
                    >Login</button>

                </form>
            </div>
        </section>
    )
}
export default LoginForm