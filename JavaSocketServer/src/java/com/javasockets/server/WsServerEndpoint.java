package com.javasockets.server;

import javax.websocket.OnClose;
import javax.websocket.OnError;
import javax.websocket.OnMessage;
import javax.websocket.OnOpen;
import javax.websocket.Session;
import javax.websocket.server.ServerEndpoint;

/**
 *
 * @author ROSZONE
 */
@ServerEndpoint("/wsServer")
public class WsServerEndpoint {

    private static final SesionManager mManager = new SesionManager();

    @OnOpen
    public void onOpen(Session session) {
        String id = session.getId();
        mManager.register(session);
        DataMessage message = DataMessage.build(id, "registrado");
        message.To = id;
        mManager.send(message.toJson(), session.getId());
    }

    @OnMessage
    public void onMessage(String message, Session session) {
        DataMessage data = DataMessage.fromJson(message);
        if (data == null) {
            data = DataMessage.build(session.getId(), "comando-desconocido");
            data.Data = message;
        }
        data.From = session.getId();
        mManager.sendBroadcast(data.toJson(), session.getId());
    }

    @OnClose
    public void onClose(Session session) {
        mManager.unRegister(session);
        DataMessage message = DataMessage.build(session.getId(), "desconectado");
        mManager.sendBroadcast(message.toJson(), "");
    }

    @OnError
    public void onError(Throwable error) {
        System.out.println("onError | " + error.getMessage());
    }
}
