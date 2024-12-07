import { HubConnectionBuilder } from "@microsoft/signalr"
import { WaitingRoom } from "./components/WaitingRoom";
import { useState } from "react";
import { Chat } from "./components/Chat";

function App() {
  const [connection, setConnection] = useState(null);
  const [chatRoom, setChatRoom] = useState("");
  const [messages, setMessages] = useState([]);

  const joinChat = async (userName, chatRoom) => {
    var connection = new HubConnectionBuilder()
      .withUrl("http://localhost:5082/chat")
      .withAutomaticReconnect()
      .build();

    connection.on("ReceiveMessage", (userName, message) => {
      setMessages((messages) => [...messages, { userName, message }])
    })

    try {
      await connection.start();
      await connection.invoke("JoinChat", { userName, chatRoom });

      setConnection(connection);
      setChatRoom(chatRoom);
    }
    catch (error) {
      console.log(error);
    }
  }


  return (
    <div className="container-fluid min-vh-100 p-0 d-flex justify-content-center align-items-center">
      {connection ? <Chat messages={messages} chatRoom={chatRoom} /> : <WaitingRoom joinChat={joinChat}/>}
    </div>
  );
}

export default App;
