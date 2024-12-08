import { useState } from "react";
import { Message } from "./Message";

export const Chat = ({ messages, chatRoom, closeChat, sendMessage }) => {
    const [message, setMessage] = useState("");

    const onSendMessage = () => {
        sendMessage(message);
        setMessage("");
    }

    return (
        <div className="col-4 bg-body shadow rounded p-3">

            <div className="d-flex justify-content-between mb-3">
                <p className="mb-0 fs-1">{chatRoom}</p>
                <button className="btn btn-close" onClick={closeChat}></button>
            </div>

            <div className="d-flex flex-column overflow-auto scroll-smooth pb-3">
                {messages.map((messageInfo, index) => (
                    <Message messageInfo={messageInfo} key={index} />
                ))}
            </div>

            <div className="d-flex">
                <input type="text" 
                    value={message} onChange={(e) => setMessage(e.target.value)}
                    placeholder="Введите сообщение"
                />
                <button className="btn btn-primary" onClick={onSendMessage}>Отправить</button>
            </div>
        </div>
    );
}