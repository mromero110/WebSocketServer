package com.javasockets.server;

import java.io.IOException;
import java.util.List;
import java.util.concurrent.ConcurrentHashMap;
import javax.websocket.Session;

/**
 *
 * @author ROSZONE
 */
public class SesionManager {

    private final ConcurrentHashMap<String, Session> mSessions = new ConcurrentHashMap<>();

    public boolean register(Session user) {
        String id = user.getId();
        if (mSessions.contains(id)) {
            return false;
        } else {
            mSessions.put(id, user);
            return true;
        }
    }

    public boolean unRegister(Session user) {
        String id = user.getId();
        if (mSessions.containsKey(id)) {
            mSessions.remove(id);
            return true;
        }
        return false;
    }

    public Session get(String id) {
        if (mSessions.containsKey(id)) {
            return mSessions.get(id);
        } else {
            return null;
        }
    }

    public void send(String msg, String id) {
        Session to = get(id);
        sendTo(msg, to);
    }

    private void sendTo(String message, Session session) {
        if (session != null && session.isOpen()) {
            try {
                session.getBasicRemote().sendText(message);
            } catch (IOException ex) {
                System.out.println("error sendTo " + " | " + ex.getMessage());
            }
        }
    }

    public void sendBroadcast(String msg, String from) {
        List<Session> list = mSessions.values().stream().toList();
        for (Session to : list) {
            if (!to.getId().equals(from)) {
                sendTo(msg, to);
            }
        }
    }
}
