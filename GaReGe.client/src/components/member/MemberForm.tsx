import {Member} from "../../types/member.ts";
import React, {useState} from "react";
import {Link} from "react-router-dom";

type Args = {
    member: Member,
    submitted: (member: Member) => void;
};

const MemberForm = ({member, submitted}: Args) => {

    const [memberState, setMemberState] = useState({...member})

    const onSubmit: React.MouseEventHandler<HTMLButtonElement> = async (e) => {
        e.preventDefault();
        submitted(memberState);
    };

    return (
        <form>
            <div className="form-group">
                <label htmlFor="firstName">First Name</label>
                <input
                    type="text"
                    className="form-control"
                    placeholder="First Name"
                    value={memberState.firstName}
                    onChange={(e) =>
                        setMemberState({
                            ...memberState,
                            firstName: e.target.value,
                        })
                    }
                />

                <label htmlFor="lastName">Last Name</label>
                <input
                    type="text"
                    className={"form-control"}
                    placeholder={"Last Name"}
                    value={memberState.lastName}
                    onChange={(e) => {
                        setMemberState({
                            ...memberState,
                            lastName: e.target.value
                        })
                    }}
                />

                <label htmlFor="ssr">Social security number</label>
                <input
                    type="text"
                    className={"form-control"}
                    placeholder={"yyyymmdd-xxxx"}
                    value={memberState.ssr}
                    onChange={(e) => {
                        setMemberState({
                            ...memberState,
                            ssr: e.target.value
                        })
                    }}
                />

                <label htmlFor="avatar">Avatar (link)</label>
                <input
                    type="text"
                    className={"form-control"}
                    placeholder={"Link"}
                    value={memberState.avatar}
                    onChange={(e) => {
                        setMemberState({
                            ...memberState,
                            avatar: e.target.value
                        })
                    }}
                />

            </div>
            <button
                className={"btn btn-primary my-3"}
                onClick={onSubmit}
            >
                Submit
            </button>
            <Link
                className={"btn btn-warning ms-2"}
                to={"/members"}
            >
                Back
            </Link>

        </form>

    );
}

export default MemberForm;


//
// const {register, handleSubmit, formState: {errors}} = useForm<CreateMemberDto>();
//
// const nav = useNavigate();
// const onSubmit = (data : CreateMemberDto) => {
//     console.log(data);
//     // You will replace this console.log with the mutation call to create a member
// };

// return (
//
//     <>
//         <div className="row ">
//             <div className="col-6">
//                 <form onSubmit={handleSubmit(onSubmit)}>
//                     <div className="mb-3">
//                         <label htmlFor="firstName" className="form-label">First Name</label>
//                         <input id="firstName" {...register('firstName', {required: true})}
//                                className="form-control"/>
//                         {errors.firstName && <span>This field is required</span>}
//                     </div>
//
//
//                     <div className="mb-3">
//                         <label htmlFor="lastName" className="form-label">Last Name</label>
//                         <input id="lastName" {...register('lastName', {required: true})} className="form-control"/>
//                         {errors.lastName && <span>This field is required</span>}
//                     </div>
//
//                     <div className="mb-3">
//                         <label htmlFor="ssr" className="form-label">Social Security Number</label>
//                         <input id="ssr" {...register('ssr', {required: true})} className="form-control"/>
//                         {errors.ssr && <span>This field is required</span>}
//                     </div>
//
//                     <div className="mb-3">
//                         <label htmlFor="avatar" className="form-label">Avatar URL</label>
//                         <input id="avatar" {...register('avatar')} className="form-control"/>
//                     </div>
//
//                     {/*<div className={"mt-4 d-flex justify-content-between"}>*/}
//                     <div className={"mt-4"}>
//                         <button type="submit" className="btn btn-primary">Submit</button>
//                         <button className="btn btn-warning ms-3" onClick={() => nav("/members")}>Go back</button>
//                     </div>
//                     {/*</div>*/}
//                 </form>
//             </div>
//         </div>
//     </>
// );
//
