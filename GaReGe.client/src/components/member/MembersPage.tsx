import MembersTable from "./MembersTable.tsx";
// import {useNavigate} from "react-router";
import {Link} from "react-router-dom";


const MembersPage = () => {

    // const nav = useNavigate(); 

    // const handleCreate = () => {
    //    
    // }
    
    return (
        <>
            <h1 className={"mb-4"}>Members</h1>
            <Link className={"btn btn-primary mb-4"} to={"/members/create"}>Register new member</Link>
            <MembersTable></MembersTable>
        </>
    );
}


export default MembersPage; 