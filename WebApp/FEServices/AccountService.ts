/*
import axios from "axios";
import type {IUserInfo} from "@/types/IUserInfo";
import type {IResultObject} from "@/types/IResultObject";
import {useAuthStore} from "@/stores/auth";

export default class AccountService {

    private static httpClient = axios.create({
        baseURL: 'http://localhost:5218/api/v1/identity/account/',
    });

    static async loginAsync(email: string, pwd: string): Promise<IResultObject<IUserInfo>> {
        const loginData = {
            email: email,
            password: pwd
        }
        try {
            const response = await AccountService.httpClient.post<IUserInfo>("login", loginData);
            if (response.status < 300) {
                return {
                    data: response.data
                }
            }
            return {
                errors: [response.status.toString() + " " + response.statusText]
            }
        } catch (error: any) {
            return {
                errors: [JSON.stringify(error)]
            };
        }
    }

    static async registerAsync(firstName: string, lastname: string, email: string, password: string): Promise<IResultObject<IUserInfo>> {
        const registerInfo = {
            lastName: lastname,
            firstName: firstName,
            email: email,
            password: password
        }

        try {
            const response = await AccountService.httpClient.post<IUserInfo>("register", registerInfo);
            if (response.status < 300) {
                return {
                    data: response.data
                }
            }
            return {
                errors: [response.status.toString() + " " + response.statusText]
            }
        } catch (error: any) {
            return {
                errors: [JSON.stringify(error)]
            };
        }
    }

    static async refreshTokenAsync(refreshToken: string, expiredJWT: string): Promise<IResultObject<IUserInfo>> {
        let url = "RefreshTokenData";
        const refreshData = {
            jwt: expiredJWT,
            refreshToken: refreshToken,
        }

        try {
            const response = await AccountService.httpClient.post<IUserInfo>(url, refreshData);
            if (response.status < 300) {
                const store = useAuthStore();
                store.jwt = response.data.jwt;
                store.refreshToken = response.data.refreshToken;
                store.userName = `${response.data.firstName} ${response.data.lastName}`;
                return {
                    data: response.data
                }
            }
            return {
                errors: [response.status.toString() + " " + response.statusText]
            }
        } catch (error: any) {
            return {
                errors: [JSON.stringify(error)]
            };
        }
    }
}
*/