import cv2
import mediapipe as mp
import socket

# Initialize MediaPipe Hands
mp_hands = mp.solutions.hands
hands = mp_hands.Hands()
mp_drawing = mp.solutions.drawing_utils

#communication
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serveraddressPort = ("127.0.0.1", 5052)

# Open a webcam
cap = cv2.VideoCapture(0)

while cap.isOpened():
    ret, frame = cap.read()
    if not ret:
        continue

    frame = cv2.flip(frame, 1)
    rgb_frame = cv2.cvtColor(frame, cv2.COLOR_BGR2RGB)
    results = hands.process(rgb_frame)

    if results.multi_hand_landmarks:
        for hand_landmarks in results.multi_hand_landmarks:
            # Get the coordinates of the center of the hand
            center_x = hand_landmarks.landmark[mp_hands.HandLandmark.WRIST].x
            # center_y = hand_landmarks.landmark[mp_hands.HandLandmark.WRIST].y

            # Draw hand landmarks on the frame
            mp_drawing.draw_landmarks(frame, hand_landmarks, mp_hands.HAND_CONNECTIONS)

            # Print the coordinates of the hand center
            # cv2.putText(frame, f"Hand Center: ({center_x:.2f})", (10, 30), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 0, 255), 2)
            coords = (1 - (-1)) * center_x + (-1)
            sock.sendto(str.encode(str(round(coords, 2))), serveraddressPort)

    cv2.imshow("Hand Tracking", frame)

    if cv2.waitKey(1) & 0xFF == ord("q"):
        break

cap.release()
cv2.destroyAllWindows()