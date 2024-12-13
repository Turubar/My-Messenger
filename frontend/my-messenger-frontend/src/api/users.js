import axios from 'axios'

const URL = "http://localhost:5270";

export const registerUserAPI = async (login, password) => {
    try {
        await axios.post(URL + "/api/users/register", {login, password})
        return {severity: "success", message: "Вы успешно зарегистрировались", success: true};
    }
    catch (error) {
        if (error.code == "ERR_NETWORK")
            return {severity: "error", message: "В данный момент сервер недоступен, попробуйте позже", success: false};
        else {
            if (error.response) {
                const { errors } = error.response.data;

                if (errors.Login) {
                    return {severity: "warning", message: errors.Login[0], success: false};
                }

                if (errors.Password) {
                    return {severity: "warning", message: errors.Password[0], success: false};
                }

                if (errors.message) {
                    return {severity: "error", message: errors.message, success: false};
                }
            }
            else {
                return {severity: "error", message: "Что-то пошло не так, попробуйте позже", success: false};
            } 
        }
    }
}