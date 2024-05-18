import axios, {AxiosError, AxiosResponse} from 'axios';
import {useMutation, useQuery, useQueryClient} from 'react-query';
import config from '../config';
import {useNavigate} from "react-router";
import {Member} from "../types/member.ts";
import Problem from "../types/problem.ts";

const useFetchMembers = () => {
    return useQuery<Member[], AxiosError>(['members'], async () => {
        const response = await axios.get(`${config.baseApiUrl}/members`);
        return response.data;
    });
};

const useFetchMemberDetail = (memberId: number) => {
    return useQuery<Member, AxiosError>(['member', memberId], async () => {
        const response = await axios.get(`${config.baseApiUrl}/members/${memberId}`);
        return response.data;
    })
}

const useAddMember = () => {
    const nav = useNavigate();
    const queryClient = useQueryClient();
    return useMutation<AxiosResponse, AxiosError<Problem>, Member>(
        (m) => axios.post(`${config.baseApiUrl}/members`, m),
        {
            onSuccess: async () => {
                await queryClient.invalidateQueries("members");
                nav("/members");
            }
        }
    );
};

const useUpdateMember = () => {
    const nav = useNavigate();
    const queryClient = useQueryClient();
    return useMutation<AxiosResponse, AxiosError<Problem>, Member>(
        (m) => axios.put(`${config.baseApiUrl}/members`, m),
        {
            onSuccess: async (_, member) => {
                await queryClient.invalidateQueries("members");
                nav(`/members/${member.memberId}`);
            }
        }
    )
};

const useDeleteMember = () => {
    const nav = useNavigate();
    const queryClient = useQueryClient();
    return useMutation<AxiosResponse, AxiosError<Problem>, Member>(
        (m) => axios.delete(`${config.baseApiUrl}/members/${m.memberId}`),
        {
            onSuccess: async (_, member) => {
                await queryClient.invalidateQueries("members");
                nav(`/members`);
            }
        }
    )
};

export {useFetchMembers, useFetchMemberDetail, useAddMember, useUpdateMember, useDeleteMember};
