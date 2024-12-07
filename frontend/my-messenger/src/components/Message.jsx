export const Message = ({ messageInfo }) => {
    return (
        <div className="bg-secondary">
            <p className="">{messageInfo.userName}</p>
            <div>
                <p>{messageInfo.message}</p>
            </div>
        </div>
    );
}