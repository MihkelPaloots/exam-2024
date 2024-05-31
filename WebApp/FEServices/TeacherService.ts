/*

import axios from 'axios';
import { useAuthStore } from '@/stores/auth';
import type {Student, TeacherData} from "@/entities/TeacherData";
import type {UnwrapRef} from "vue";

const API_BASE_URL = 'http://localhost:5218/api/v1/Teacher';

export default class TeacherService {
    static async getTeacherData(): Promise<TeacherData> {
        const store = useAuthStore();
        const httpClient = axios.create({
            baseURL: API_BASE_URL,
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${store.jwt}`
            }
        });

        try {
            const response = await httpClient.get<TeacherData>('/GetSubjectsWithStudents');
            return response.data;
        } catch (error: any) {
            console.error('Failed to fetch student data:', error);
            throw error;
        }
    }

    static async enrollStudents(subjectId: string, studentIds: string[]) {
        console.log('Enrolling students:', studentIds)
        const store = useAuthStore();
        const httpClient = axios.create({
            baseURL: API_BASE_URL,
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${store.jwt}`
            }
        });

        try {
            const response = await httpClient.post('/EnrollStudents', { subjectId, studentIds });
            return response.data;
        } catch (error: any) {
            console.error('Failed to fetch student data:', error);
            throw error;
        }
    }

    static async createHomework(subjectId: string, value: UnwrapRef<{
        dueDate: string;
        description: string;
        title: string
    }>) {
        const store = useAuthStore();
        const httpClient = axios.create({
            baseURL: API_BASE_URL,
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${store.jwt}`
            }
        });

        try {
            const response = await httpClient.post('/AddHomework', { subjectId, homework: value });
            return response.data;
        } catch (error: any) {
            console.error('Failed to fetch student data:', error);
            throw error;
        }

    }

    static async getStudentsBySubject(subjectId: string) {
        const store = useAuthStore();
        const httpClient = axios.create({
            baseURL: API_BASE_URL,
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${store.jwt}`
            }
        });

        try {
            const response = await httpClient.get<Student[]>(`/GetStudentsBySubject?subjectId=${subjectId}`);
            return response.data;
        } catch (error: any) {
            console.error('Failed to fetch student data:', error);
            throw error;
        }
    }
}


 */