class TodoService{
    _base = 'http://localhost:5255/api/ToDo'

    register = async (e, email, password) => {
        let statusCode;
        e.preventDefault();
        let result = await fetch("http://localhost:5255/api/Auth/register",
            {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                credentials: "include",
                body: JSON.stringify({
                    email: email,
                    password: password
                })
            }).then((response)=>{
                if (response.status !== 200) throw (response.status)
                statusCode = response.status;
                return response.json();
        }).then((result)=>{
            localStorage.setItem("accessToken", result.accessToken)
        })
            .catch((error)=>{
                console.log(error);
            })
        return statusCode;
    }

    login = async (e, email, password) => {
        let statusCode;
        e.preventDefault();
        let result = await fetch("http://localhost:5255/api/Auth/login",
            {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                credentials: "include",
                body: JSON.stringify({
                    email: email,
                    password: password
                })
            }).then((response)=>{
                if (response.status !== 200) throw (response.status)
            statusCode = response.status;
                return response.json();
        }).then(result=>{
            localStorage.setItem('accessToken', result.accessToken)
        }).catch((error)=>{
            console.log(error);
        })
        return statusCode;
    }

    async AddItem(text){
        return await fetch(this._base, {
            method: "POST",
            headers:{
                "Authorization": `Bearer ${localStorage.getItem('accessToken')}`,
                "Content-Type": 'application/json'
            },
            body: JSON.stringify({text: text})
        })
    }

    async getAll(){
        const resource = await fetch(`${this._base}?page=1&pageSize=100`,
            {
                method:"GET",
                headers:{
                    "Authorization": `Bearer ${localStorage.getItem('accessToken')}`,
                    "Content-Type": 'application/json'
                }
            })
        const result = await resource.json()
        return result.items
    }
}
export default TodoService