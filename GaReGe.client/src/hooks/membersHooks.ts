import axios, {AxiosError} from 'axios';
import {useQuery} from 'react-query';
import {Member, MemberDetail} from '../types/member';
import config from '../config';

const useFetchMembers = () => {
    return useQuery<Member[], AxiosError>(['members'], async () => {
        const response = await axios.get(`${config.baseApiUrl}/members`);
        return response.data;
    });
};

const useFetchMemberDetail = (memberId : number) => {
    return useQuery<MemberDetail, AxiosError>(['member', memberId], async () => {
        const response = await axios.get(`${config.baseApiUrl}/members/${memberId}`);
        return response.data; 
    })
}


export {useFetchMembers, useFetchMemberDetail};
