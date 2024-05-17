import {useFetchMemberDetail} from "../../hooks/membersHooks.ts";
import ApiStatus from "../api/ApiStatus.tsx";
import {useParams} from "react-router";

const MemberDetail = () => {
    const {id} = useParams();
    if (!id) throw Error("No house id provided");
    const memberId = parseInt(id);

    const {data, status, isSuccess, isFetching, isLoading} = useFetchMemberDetail(memberId);

    if (isLoading || isFetching) {
        return <ApiStatus status="loading" />;
    }

    if (!isSuccess) {
        return (<ApiStatus status={status}/>)
    }

    return (


        <>
            <h1 className={"mb-4"}>{`${data.firstName} ${data.lastName}`}</h1>
            <div className="row">

                <div className="col-6">
                    <div className="row">
                        <div className="col-5">
                            <p>Member ID: </p>
                            <p>Social security number: </p>


                        </div>

                        <div className="col-5">
                            <p>{data.memberId}</p>
                            <p>{data.ssr}</p>
                        </div>


                    </div>
                </div>

                <div className="col-6">

                    <img className="img-fluid" src={data.avatar} alt="Portrait"/>
                </div>

            </div>

        </>


    );

}


export default MemberDetail; 