
/*
import axios from 'axios';
import { useAuthStore } from '@/stores/auth';
import type {StudentData, Subject} from '@/entities/StudentData';

const API_BASE_URL = 'http://localhost:5218/api/v1/Student';

export default class StudentService {
    static async getStudentData(): Promise<StudentData> {
        const store = useAuthStore();
        const httpClient = axios.create({
            baseURL: API_BASE_URL,
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${store.jwt}`
            }
        });

        try {
            const response = await httpClient.get<StudentData>('/GetStudentData');
            return response.data;
        } catch (error: any) {
            console.error('Failed to fetch student data:', error);
            throw error;
        }
    }

    static async getAvailableSubjects(): Promise<Subject[]> {
        const store = useAuthStore();
        const httpClient = axios.create({
            baseURL: 'http://localhost:5218/api/v1/Subjects',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${store.jwt}`
            }
        });

        try {
            const response = await httpClient.get<Subject[]>('/GetSubjects');
            return response.data;
        } catch (error: any) {
            console.error('Failed to fetch student subjects:', error);
            throw error;
        }
    }

    static async addSubject(subjectId: string): Promise<void> {
        const store = useAuthStore();
        const httpClient = axios.create({
            baseURL: 'http://localhost:5218/api/v1/Student',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': `Bearer ${store.jwt}`
            }
        });

        try {
            await httpClient.post(`/RegisterToSubject`, { subjectId });
        } catch (error: any) {
            console.error('Failed to add subject:', error);
            throw error;
        }
    }

}
*/