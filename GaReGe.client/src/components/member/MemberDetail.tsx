import {useDeleteMember, useFetchMemberDetail} from "../../hooks/membersHooks.ts";
import ApiStatus from "../api/ApiStatus.tsx";
import {useParams} from "react-router";
import {Link} from "react-router-dom";

const MemberDetail = () => {
    const {id} = useParams();
    if (!id) throw Error("No house id provided");
    const memberId = parseInt(id);

    const {data: member, status, isSuccess, isFetching, isLoading} = useFetchMemberDetail(memberId);

    const deleteMemberMutation = useDeleteMember();

    if (isLoading || isFetching) {
        return <ApiStatus status="loading"/>;
    }

    if (!isSuccess || !member) {
        return (<ApiStatus status={status}/>)
    }
    
    return (
        <>
            <h1 className={"mb-4"}>{`${member.firstName} ${member.lastName}`}</h1>
            <div className={"d-flex"}></div>
            <Link
                to={`/members/${member.memberId}/update`}
                className={"btn btn-primary"}

            >
                Edit
            </Link>
            <button
                onClick={() => deleteMemberMutation.mutate(member)}
                className={"btn btn-danger ms-2"}
            >
                Delete
            </button>
            <div className="row mt-3">

                <div className="col-6">
                    <div className="row">
                        <div className="col">
                            <p>Member ID: </p>
                            <p>Social security number: </p>
                        </div>

                        <div className="col">
                            <p>{member.memberId}</p>
                            <p>{member.ssr}</p>
                        </div>
                    </div>
                </div>


                <div className="col-6">
                    <img className="img-fluid" src={member.avatar} alt="Portrait"/>
                </div>

                <div className="row mt-3">
                    <div className="col">
                        {member.description}
                    </div>
                </div>
            </div>
        </>
    );
}


export default MemberDetail;

// const {
//     firstName,
//     lastName,
//     memberId: idFromData,
//     ssr,
//     avatar,
//     description
// } = member;
