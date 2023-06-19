

const mutate ='mutation{todo{changeStore}}';
export const changeStore = ()=>{
    fetch("http://localhost:5266/graphql",{
        method:"POST",
        headers: {
            'Content-Type': 'application/json',
            'Cache-Control': 'no-store'
        },
        body:JSON.stringify({query:mutate})
    }).then(response=>{
        return response.json()
    });
}