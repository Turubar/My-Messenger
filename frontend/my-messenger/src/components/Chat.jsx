import { Message } from "./Message";

export const Chat = ({messages, chatRoom, closeChat }) => {
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
        </div>
    );
}