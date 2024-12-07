import { HubConnectionBuilder } from "@microsoft/signalr"
import { WaitingRoom } from "./components/WaitingRoom";

function App() {
  const joinChat = async (userName, chatRoom) => {
    var connection = new HubConnectionBuilder()
      .withUrl("http://localhost:5082/chat")
      .withAutomaticReconnect()
      .build();

    try {
      await connection.start();
      await connection.invoke("JoinChat", {userName, chatRoom});

      console.log(connection);
    }
    catch (error) {
      console.log(error);
    }
  }


  return (
    <div className="container-fluid min-vh-100 p-0 d-flex justify-content-center align-items-center">
      <WaitingRoom joinChat={joinChat}/>
    </div>
  );
}

export default App;
