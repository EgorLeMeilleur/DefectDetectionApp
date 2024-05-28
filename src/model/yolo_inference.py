import cv2
import numpy as np
from ultralytics import YOLO
import json

model = YOLO('best.pt')

def run_inference(image_path):
    image = cv2.imread(image_path)
    results = model(image)
    
    detections = []
    for result in results:
        for det in result.boxes.data.tolist():
            x1, y1, x2, y2, conf, cls = det
            detections.append({
                'x1': x1, 'y1': y1, 'x2': x2, 'y2': y2
            })
    return json.dumps(detections)

if __name__ == "__main__":
    import sys
    image_path = sys.argv[1]
    print(run_inference(image_path))