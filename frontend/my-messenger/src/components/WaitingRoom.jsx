import { useState } from "react";

export const WaitingRoom = ({ joinChat }) => {
    const [userName, setUserName] = useState();
    const [chatRoom, setChatRoom] = useState();

    const onSubmit = (e) => {
        e.preventDefault();
        joinChat(userName, chatRoom);
    }

    return <form onSubmit={onSubmit} className="col-3 bg-body shadow rounded p-3">
        <div className="mb-2">
            <p className="mb-0 fs-1">Онлайн чат</p>
        </div>

        <div className="mb-4">
            <p className="mb-0 fs-5">Имя пользователя</p>
            <input 
                onChange={(e) => setUserName(e.target.value)}
                className="fs-5 w-100" type="text" name="userName" 
                placeholder="Введите ваше имя"
            />
        </div>

        <div className="mb-4">
            <p className="mb-0 fs-5">Название чата</p>
            <input 
                onChange={(e) => setChatRoom(e.target.value)}
                className="fs-5 w-100" type="text" name="chatRoom"
                placeholder="Введите название чата"
            />
        </div>

        <div className="d-flex justify-content-end">
            <button className="btn btn-primary fs-5" type="submit">Присоединиться</button>
        </div>
    </form>
};